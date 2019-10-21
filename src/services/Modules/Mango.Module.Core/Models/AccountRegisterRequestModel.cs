﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mango.API.ApiModels
{
    public class AccountRegisterRequestModel
    {
        /// <summary>
        /// 用户账号名
        /// </summary>
        public string AccountName { get; set; }
        /// <summary>
        /// 登录密码
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// 昵称
        /// </summary>
        public string NickName { get; set; }
        /// <summary>
        /// 邮箱注册验证码
        /// </summary>
        public string ValidateCode { get; set; }
    }
}
