using ComunicationWpfAngular.Contracts;
using System.Threading.Tasks;

namespace ComunicationWpfAngular.Api
{
    public interface IMessageReceiver
    {
        Task Execute(string message);
    }
}