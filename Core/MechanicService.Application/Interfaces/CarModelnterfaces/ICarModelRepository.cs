namespace MechanicService.Application.Interfaces.CarModelnterfaces
{
    public interface ICarModelRepository
    {
        List<CarModel> GetCarModelsByCarBrandId(int id);
    }
}
