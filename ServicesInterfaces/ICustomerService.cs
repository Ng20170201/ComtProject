namespace ServicesInterfaces
{
    public interface ICustomerService
    {
        public Task<bool> AddCustomerReward(string id);
    }
}