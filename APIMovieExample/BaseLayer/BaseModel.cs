using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIMovieExample.BaseLayer
{
    public class BaseModel
    {
        // A base class that will be used afterwards for syncing the changed properties in a cacheManager and so on.
        private String _className;
        private List<String> _changedProperties;

        public BaseModel()
        {
            _changedProperties = new List<string>();
        }

        public List<String> GetChangedProperties()
        {
            return _changedProperties;
        }

        public void AddChangedProperty(String propertyName)
        {
            if (!_changedProperties.Contains(propertyName))
                _changedProperties.Add(propertyName);
        }

    }
}
