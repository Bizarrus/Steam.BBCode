namespace Steam.BBCode {
    class Component {
        protected string value = null;

        public virtual void Create(string value, string attributes) {
            this.value = value;
        }

        public string GetContent() {
            return this.value;
        }
    }
}
