namespace MediatorPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            //常规版中介模式
            // Mediator.EstateMedium medium = new Mediator.EstateMedium();
            // Mediator.Seller seller = new Mediator.Seller("房东小李", medium);
            // Mediator.Buyer buyer = new Mediator.Buyer("租户小刘", medium);
            // Mediator.Manager manager = new Mediator.Manager("物业", medium);
            // medium.Register(seller);
            // medium.Register(buyer);
            // medium.Register(manager);
            // seller.Send("租户小刘", "房租1000/月。");
            // buyer.Send("房东小李", "可不可以便宜点？");
            // manager.Send("租户小刘", "这个月物业费交一下");
            
            //简化版中介模式
            var simpleMedium = SimpleMediator.EstateMedium.GetEstateMedium();
            SimpleMediator.Seller seller1 = new SimpleMediator.Seller("房东小李");
            SimpleMediator.Buyer buyer1 = new SimpleMediator.Buyer("租户小刘");
            SimpleMediator.Manager manager1 = new SimpleMediator.Manager("物业");
            simpleMedium.Register(seller1);
            simpleMedium.Register(buyer1);
            simpleMedium.Register(manager1);
            seller1.Send("租户小刘", "房租1000/月。");
            buyer1.Send("房东小李", "可不可以便宜点？");
            manager1.Send("租户小刘", "这个月物业费交一下");
        }
    }
}
