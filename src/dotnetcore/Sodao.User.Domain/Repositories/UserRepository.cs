﻿using Microsoft.Extensions.Configuration;
using Sodao.Core.Data;
using Sodao.User.Domain.Contracts;
using Sodao.User.Domain.Entities;
using System;

namespace Sodao.User.Domain.Repositories
{
    public class UserRepository : BaseRepository<UserEntity>, IUserRepository
    {
        public UserRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public override Func<string> TableNameFunc => () =>
        {
            var tableName = $"{GetMainTableName()}_Test";
            return tableName;
        };

        public override Func<string, string> CreateScriptFunc => (tableName) =>
        {
            return "CREATE TABLE `" + tableName + "` (" +
                   "  `UserId` int(11) NOT NULL AUTO_INCREMENT," +
                   "  `UserName` varchar(200) DEFAULT NULL," +
                   "  `Password` varchar(200) DEFAULT NULL," +
                   "  `RealName` varchar(200) DEFAULT NULL," +
                   "  `AddTime` datetime DEFAULT NULL," +
                   "  `IsSex` bit(1) DEFAULT NULL," +
                   "  `JsonValue` json DEFAULT NULL," +
                   "  `Join` varchar(255) DEFAULT NULL," +
                   "  `ENValue` int(11) DEFAULT NULL," +
                   "  PRIMARY KEY(`UserId`)" +
                   ") ENGINE = InnoDB AUTO_INCREMENT = 3748 DEFAULT CHARSET = utf8mb4; ";
        };
    }
}