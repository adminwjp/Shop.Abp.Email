dotnet ef migrations add a1 -o Migrations --project E:\work\csharp\src\Shop\Shop.Abp.Email\Shop.Abp.Email.EntityFrameworkCore
dotnet ef database update --project E:\work\csharp\src\Shop\Shop.Abp.Email\Shop.Abp.Email.EntityFrameworkCore

Unhandled exception. System.TypeLoadException: Method 'GetActiveTransactionAsync
' in type 'Abp.EntityFrameworkCore.EfCoreActiveTransactionProvider' from assembl
y 'Abp.EntityFrameworkCore, Version=5.14.0.0, Culture=neutral, PublicKeyToken=nu
ll' does not have an implementation.
统一 版本  
ef core 怎么 区分 多 数据库 
这可能是因为该项目已被卸载或不属于当前解决方案，因此请从命令行运行还原。否则，项目文件可能无效或缺少还原所需的目标 
调试 时  最好 都用 源码 别用nuget 或 源码 混用
abp ef core  不能 跟 utility 混合 搭配 使用 可能 类库出现问题(Ef)
The configured execution strategy 'MySqlRetryingExecutionStrategy' does not support user initiated transactions. Use the execution strategy
returned by 'DbContext.Database.CreateExecutionStrategy()' to execute all the operations in the transaction as a retriable unit.
abp 封装 太厉害 了 就报个错 具体 原因 未知

https://www.bookstack.cn/read/Microsoft.EntityFrameworkCore.Docs.zh-Hans/11%E3%80%81%E5%85%B6%E4%BB%96-D%E3%80%81%E5%BC%B9%E6%80%A7%E8%BF%9E%E6%8E%A5.md


DbContext.Database.CreateExecutionStrategy() 这个方法怎么找不到 abp
