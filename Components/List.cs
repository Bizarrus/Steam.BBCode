using System;
using System.Collections.Generic;
using System.Text;

namespace Steam.BBCode.Components {
    class List : Component {
        private List<string> entries = new List<string>();

        public override void Create(string value, string attributes) {
            string[] split = value.Split("[*]".ToCharArray());

            foreach (string entry in split) {
                if (entry.Trim().Length == 0) {
                    continue;
                }

                this.entries.Add(entry.Trim());
            }
        }

        public List<string> GetItems() {
            return this.entries;
        }
    }
}
