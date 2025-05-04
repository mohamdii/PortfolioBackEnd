using Portfolio.API.BaseRepositoy.Interfaces;
using Portfolio.API.Data.Experience;
using System.Runtime.InteropServices;

namespace Portfolio.API.Event
{
    public class OnCompleteEvent
    {
        public delegate void PublishRegisteredEventHandler(object sourcce, EventArgs e);
        public event PublishRegisteredEventHandler PublishRegistered;
        
        private readonly IBaseRepository<Employee> _baseRepository;
        public OnCompleteEvent(IBaseRepository<Employee> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public void Publish()
        {
            _baseRepository.Add(new Employee
            {
                //Id = Guid.NewGuid(),

            });

            OnPublishRegistered();
        }

        protected virtual void OnPublishRegistered()
        {
            if (PublishRegistered != null)
            {
                PublishRegistered(this, EventArgs.Empty);
            }
        }
    }
}
