﻿using Furniture_Shop_Backend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Furniture_Shop_Backend.ViewModels.Common;

namespace Furniture_Shop_Backend.Services.ProductImages
{
    public class ProductImagesService : IProductImagesService
    {
        private readonly FurnitureShopContext _context;
        public ProductImagesService(FurnitureShopContext context) {
            _context = context;
        }

        public async Task<List<string>> GetUrlsByIdProductbase(string idProductbase)
        {
            var query = from im in _context.ProductImages
                        orderby im.Priority
                        select new { im };
           if (!string.IsNullOrEmpty(idProductbase))
            {
                query = query.Where(c => c.im.ProductBasetId.Equals(idProductbase));
            }
            else
            {
                throw new System.Exception();
            }
            var data = await query.Select(e => e.im.Url).ToListAsync();
            return data;
        }

        public async Task<ApiResult<bool>> setUrlImages(string idProductbase, List<string> urlImages)
        {   
            var queryP = from p in _context.Products
                         select p;
            var rs = await queryP.Where(p => p.ProductBaseId.Equals(idProductbase)).FirstOrDefaultAsync();
            if (rs is null)
            {
                return  new ApiErrorResult<bool>($"Can't find product with Produt base id: {idProductbase}");
            }
            int count = 1;
            // delete all immage if exist
            var del = await _context.ProductImages.Where(p => p.ProductBasetId == idProductbase).ToListAsync();
            foreach(var image in del)
            {
                _context.ProductImages.Remove(image);
            }
            // set new images list
            foreach(var item in urlImages)
            {
                var productImage = new ProductImage()
                {
                    ProductBasetId = idProductbase,
                    ProductId = 1,
                    Priority = count++,
                    Url = item,

                };
                _context.ProductImages.Add(productImage);
                await _context.SaveChangesAsync();
            }
            return new ApiSuccessResult<bool>();
        }
    }
}
