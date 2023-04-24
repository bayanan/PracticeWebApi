using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiPractice.BusinessLogic.Limits
{
    public class RequestLimiter
    {
        private int _currentRequestsCount = 0;
        private int _maxRequestsCount;
        private static RequestLimiter instance;

        public static RequestLimiter GetRequestLimiter(int maxRequestCount=-1)
        {
            if (maxRequestCount == -1 && instance == null)
                throw new ArgumentNullException("maxRequestCount cannot by null while RequestLimiter does not initialized");
            if (instance == null)
                instance = new RequestLimiter(maxRequestCount);
            return instance;
        }

        private RequestLimiter(int maxRequestsCount)
        {
            _maxRequestsCount = maxRequestsCount;
        }

        public bool TryAcquireRequest()
        {
            lock (this)
            {
                if (_currentRequestsCount >= _maxRequestsCount)
                {
                    return false;
                }

                _currentRequestsCount++;
                return true;
            }
        }

        public void ReleaseRequest()
        {
            lock (this)
            {
                _currentRequestsCount--;
            }
        }
    }
}
