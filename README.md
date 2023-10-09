# auto-migration

ef core auto migration

link [#6214](https://github.com/dotnet/efcore/issues/6214) | [#3053](https://github.com/dotnet/efcore/issues/3053)

sample [AutoMigration](https://gist.github.com/lakeman/1509f790ead00a884961865b5c79b630/) [EFCoreAutoMigrator](https://github.com/centridsol/EFCoreAutoMigrator)

迁移模式分类：

-   Design 模式下迁移
    -   暴力迁移，直接重置库
-   Produce 模式下迁移
    -   Produce 模式下，与 Release 大致相同，但是会缺少一些维护数据的措施
-   Release 模式下迁移
    -   Release 模式下不仅是对表结构的调整，还可能包含对于表数据的调整，并且表数据需要进行迁移维护，以防止意料之外的情况发生；
    -   需要表结构调整和数据调整交叉进行，所以需要维护顺序，就需要迁移有明显的标识特征
    -   对于正式环境的直接错误迁移是灾难性的，所以需要一些中断确认

设计：

-   采用独立的迁移程序来简化生成迁移的操作
    -   采用各种特性来丰富迁移顺序调整
    -   采用特性给迁移附加数据迁移
-   代码通过`__EFMigrationHistory`和其它信息相结合来管理迁移
    -   详细迁移信息表
    -   迁移和数据迁移的对照表
    -   数据迁移和备份表的对照表
-   迁移工作台
    -   用于查看迁移信息，包括特性、绑定的数据迁移以及其它说明
        -   已应用迁移的迁移状态
        -   未应用迁移的状态
    -   详细迁移数据
    -   手动调整迁移

其它设想：

-   表滚动迁移
    -   迁移不再是对表进行更改，而是对于旧表的副本进行修改，并且重新映射实体到新表
    -   表版本映射
