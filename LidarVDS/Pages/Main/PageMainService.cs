using System;
using System.Collections.Generic;
using System.Windows.Documents;
using HandyControl.Controls;
using LidarVDS.Utils;

namespace LidarVDS;

/**
 * 负责页面的一些业务逻辑
 */
public class PageMainService
{
    private PageMainService() {}

    public static readonly PageMainService Instance = new();
    public List<string> GetCommand()
    {
        //TODO 从历史操作记录中获取最近几次操作的信息摘要
        return new List<string>(){"2023/4/10 8:01 保存 激光雷达配置文件1","2023/4/10 8:00 编辑 激光雷达配置文件1","2023/4/10 7:59 创建 激光雷达配置文件1"};
    }

    public List<string> GetAnnouncements()
    {
        return new List<string>() { "公告第一行", "公告第二行", "公告第三行" };
    }
}