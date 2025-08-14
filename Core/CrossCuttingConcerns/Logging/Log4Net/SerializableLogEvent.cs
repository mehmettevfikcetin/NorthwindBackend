using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net.Core;


//bu sayfa log4net kütüphanesini kullanarak loglama işlemlerini gerçekleştiren bir sınıf tanımlar.
// Bu sınıf, loglama olayını serileştirmek için kullanılır.

namespace Core.CrossCuttingConcerns.Logging.Log4Net
{
    [Serializable]
    public class SerializableLogEvent
    {
        private LoggingEvent _loggingEvent;
        public SerializableLogEvent(LoggingEvent loggingEvent)
        {
            _loggingEvent = loggingEvent;
        }
        public object Message => _loggingEvent.MessageObject;
        
    }
}
