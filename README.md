# StandardMVC
一个常见MVC项目代码骨架，采用多分层：主要分为领域层、数据层、应用层、Web层，整体面向接口编程，通过Autofac实现IoC，另外用到查询规约、Dto  

Demo前缀的是业务相关模块，可以将Demo改为您的项目名称。  
Demo.Data 数据访问层  
Demo.Domain  领域层，存放数据模型类  
Demo.Service  服务层，存放核心业务逻辑  
Demo.Dto  视图映射层，做数据模型和前端视图模型匹配  
Demo.Web  Web层，存放页面、控制器以及其他web层公用设施  

以下业务无关
Data.Seedwork  数据公用设施  
Domain.Seedwork 领域公用类  
Infrastucture 基础设施层  

领域层Domain：业务模型层、业务相关查询规约  
数据层Data:数据层，提供各个业务模块的数据库访问仓储类  
应用层Application: 服务层，核心业务逻辑封装  
Web层: 负责路由处理、调用应用层接口对外提供web服务  

