# SimpleBackOffice
[English](https://github.com/Singway/SimpleBackOffice) / 中文

    本人之前是再零售行业从事管理，由于多个原因，想转行写代码，
    但是发现没有个项目真的很难去展现自己，
    而且自学了ASP.Net Core一段时间了，一直想自己写一个项目练手，
    所以最近我起草了这个后台管理项目，里面带有最基础的一些功能。
    
    这个项目使用了 .NET Core + EF Core + HTML 5 + Bootstrap  + jQuery +NLog 搭建
    
  ## 主要功能:
    1.字典结构配置部门
    2.提供角色，部门，用户授权  
      角色对用户授权  
      角色对部门授权   
      部门对用户授权  
    3.内置“操作日志”“登录日志”记录主机、用户信息
    4.完全响应式布局
    5.实现本地、远程信息验证
      
  ## 数据库
    支持 MSSQL/Oracle/SQLite....（默认MSSQL）
    使用其他数据库只需要修改连接配置并使用EF Core迁移
    
    
    这个项目还有很多需要改进的地方，并且本人也会逐步地将其完善，必要时重构。
    非常真诚地欢迎各位留下宝贵的建议，也可以直接加入到这个项目来，谢谢~
    
  ## 目前的部分项目截图
  
![home](https://github.com/Singway/SimpleBackOffice/blob/master/ReadMe/home.jpg)
![roleDept](https://github.com/Singway/SimpleBackOffice/blob/master/ReadMe/roleDept.png)
![lock](https://github.com/Singway/SimpleBackOffice/blob/master/ReadMe/lock.png)
![phonePage](https://github.com/Singway/SimpleBackOffice/blob/master/ReadMe/phonePage.png)
![errorLog](https://github.com/Singway/SimpleBackOffice/blob/master/ReadMe/errorLog.png)
