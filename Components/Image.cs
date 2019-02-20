using System;
using System.Collections.Generic;
using System.Text;

namespace Steam.BBCode.Components {
    class Image : Component {
        public string GetURL() {
            return this.value;
        }
    }
}
