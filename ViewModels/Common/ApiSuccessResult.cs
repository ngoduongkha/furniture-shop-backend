﻿namespace Furniture_Shop_Backend.ViewModels.Common {
    public class ApiSuccessResult<T> : ApiResult<T> {
        public ApiSuccessResult(T resultObj) {
            IsSuccessed = true;
            ResultObj = resultObj;
        }

        public ApiSuccessResult()
        {
            IsSuccessed = true;
        }
    }
}
