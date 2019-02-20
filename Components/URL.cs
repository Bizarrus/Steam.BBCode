using System.Text.RegularExpressions;

namespace Steam.BBCode.Components {
    class URL : Component {
        protected string url = null;

        public override void Create(string value, string attributes) {
            Regex regex = new Regex("\\[url=(.*)\\](.*)");
            MatchCollection results = regex.Matches(value);

            if (!regex.IsMatch(value)) {
                this.value = value;
            } else {
                this.url = results[0].Groups[1].Value;
                this.value = results[0].Groups[2].Value.Trim();
            }
        }

        public string GetURL() {
            return this.url;
        }
    }
}
