using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Reflection;

namespace redis_Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            Student student1 = new Student() { Id = 1, Name = "张三", Class = "三年一班" };
            Student student2 = new Student() { Id = 2, Name = "李四", Class = "三年二班" };
            Student student3 = new Student() { Id = 3, Name = "王五", Class = "三年三班" };
            Student student4 = new Student() { Id = 4, Name = "赵六", Class = "三年四班" };
            Student student5 = new Student() { Id = 5, Name = "甲甲", Class = "三年五班" };
            Student student6 = new Student() { Id = 6, Name = "乙乙", Class = "三年六班" };
            List<Student> list = new List<Student>();
            list.Add(student1);
            list.Add(student2);
            list.Add(student3);

            #region String
            ////添加单个
            //RedisHelper.StringSet("string", "hello world", 6, RedisFolderEnum.Folder1);

            ////批量添加
            //var keys = new[] { "string1", "string2", "string3" };
            //var values = new[] { "value1", "value2", "value3" };
            //RedisHelper.StringSet(keys, values);

            ////添加对象
            //RedisHelper.StringSet<Student>("stringModel", student1, 6, RedisFolderEnum.Folder3, RedisDBEnum.Two);

            ////获取单个
            //var value = RedisHelper.StringGet("string", RedisFolderEnum.Folder1);
            //Console.WriteLine(value);

            ////获取多个
            //var values_ = RedisHelper.StringGet(new List<string>() { "string1", "string2", "string3" }).ToStringArray();
            //Console.WriteLine();

            ////获取对象
            //var model = RedisHelper.StringGet<Student>("stringModel", RedisFolderEnum.Folder3, RedisDBEnum.Two);
            //Console.WriteLine();
            #endregion

            #region List
            //插入List
            //RedisHelper.ListRightPush("list", student1, RedisFolderEnum.Folder4);
            //RedisHelper.ListRightPush("list", student2, RedisFolderEnum.Folder4);
            //RedisHelper.ListRightPush("list", student3, RedisFolderEnum.Folder4);

            ////批量插入
            //RedisHelper.ListRightPush("list", list, RedisFolderEnum.Folder4);
            //RedisHelper.ListLeftPush("list", list, RedisFolderEnum.Folder4);

            ////获取
            //var student = RedisHelper.ListRange<Student>("list", 0, -1, RedisFolderEnum.Folder4);
            //Console.WriteLine();

            ////获取特定
            //var student_ = RedisHelper.ListGetByIndex<Student>("list", 2, RedisFolderEnum.Folder4);
            //Console.WriteLine();

            ////删除指定
            //RedisHelper.ListRemove<Student>("list", student2, 0, RedisFolderEnum.Folder4);

            ////获取个数
            //var count = RedisHelper.ListLength("list", RedisFolderEnum.Folder4);
            //Console.WriteLine(count);
            #endregion

            #region Hash
            //添加
            RedisHelper.HashSet<Student>("hash", "h1", student1, RedisFolderEnum.Folder1, RedisDBEnum.Two);
            RedisHelper.HashSet<Student>("hash", "h2", student2, RedisFolderEnum.Folder1, RedisDBEnum.Two);

            ////获取特定
            //var hash1 = RedisHelper.HashGet<Student>("hash", "h2", RedisFolderEnum.Folder1, RedisDBEnum.Twelve);
            //Console.WriteLine();

            ////是否存在
            //var hashIfExists = RedisHelper.HashExists("hash", "h3", RedisFolderEnum.Folder1, RedisDBEnum.Twelve);
            //Console.WriteLine(hashIfExists);

            ////移除特定
            //RedisHelper.HashDelete("hash", "h1", RedisFolderEnum.Folder1, RedisDBEnum.Twelve);

            ////移除多个
            //RedisHelper.HashSet<Student>("hash", "h1", student1, RedisFolderEnum.Folder1, RedisDBEnum.Twelve);
            //RedisHelper.HashSet<Student>("hash", "h3", student3, RedisFolderEnum.Folder1, RedisDBEnum.Twelve);
            //RedisHelper.HashDelete("hash", new List<RedisValue>() { "h2", "h3" }, RedisFolderEnum.Folder1, RedisDBEnum.Twelve);

            ////批量获取
            //RedisHelper.HashSet<Student>("hash", "h2", student2, RedisFolderEnum.Folder1, RedisDBEnum.Twelve);
            //RedisHelper.HashSet<Student>("hash", "h3", student3, RedisFolderEnum.Folder1, RedisDBEnum.Twelve);
            //var hashMul = RedisHelper.HashGet<Student>("hash", new RedisValue[] { "h2", "h3" }, RedisFolderEnum.Folder1, RedisDBEnum.Twelve);
            //Console.WriteLine();

            ////获取所有
            //var hashTotal = RedisHelper.HashGetAll<Student>("hash", RedisFolderEnum.Folder1, RedisDBEnum.Twelve);
            //Console.WriteLine();
            #endregion

            #region Zset
            ////添加
            //RedisHelper.SortedSetAdd<Student>("zsort", student1, 111, RedisFolderEnum.Folder1, RedisDBEnum.Ten);
            //RedisHelper.SortedSetAdd<Student>("zsort", student2, 99, RedisFolderEnum.Folder1, RedisDBEnum.Ten);
            //RedisHelper.SortedSetAdd<Student>("zsort", student3, 100, RedisFolderEnum.Folder1, RedisDBEnum.Ten);
            //RedisHelper.SortedSetAdd<Student>("zsort", student4, 1, RedisFolderEnum.Folder1, RedisDBEnum.Ten);
            //RedisHelper.SortedSetAdd<Student>("zsort", student5, 201, RedisFolderEnum.Folder1, RedisDBEnum.Ten);
            //RedisHelper.SortedSetAdd<Student>("zsort", student6, 888, RedisFolderEnum.Folder1, RedisDBEnum.Ten);

            ////获取
            //var value_ = RedisHelper.SortedSetRangeByRank<Student>("zsort", 0, -1, Order.Descending, RedisFolderEnum.Folder1, RedisDBEnum.Ten);

            ////删除
            //RedisHelper.SortedSetRemove<Student>("zsort", student1, RedisFolderEnum.Folder1, RedisDBEnum.Ten);

            ////批量删除（根据对象）
            //RedisHelper.SortedSetRemove("zsort", list, RedisFolderEnum.Folder1, RedisDBEnum.Ten);

            ////批量删除（根据score删除）
            //RedisHelper.SortedSetRemoveRangeByScore("zsort", 1, 200, RedisFolderEnum.Folder1, RedisDBEnum.Ten);
            #endregion

            #region key
            //var v = RedisHelper.KeyExists("hash");
            //Console.WriteLine(v);
            
            //redis针对针对hash的key来设置缓存时间--sean
            RedisHelper.KeyExpire("hash", 1,RedisFolderEnum.Folder1,RedisDBEnum.Two);

            //RedisHelper.KeyDelete("zsort", RedisFolderEnum.Folder1, RedisDBEnum.Ten);

            //批量删除
            //RedisHelper.KeyDelete(new List<string>() { "string", "string3" });

            //RedisHelper.KeyRename("string", "gnirts", RedisFolderEnum.Folder1, RedisDBEnum.One);
            #endregion

            Console.WriteLine();
        }

        public class Student
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Class { get; set; }
        }

    }
}
