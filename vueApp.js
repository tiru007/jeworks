const url = "/api/getdevices";

const vm = new Vue({
        el: '#app',
        data: {
          items: []
        },
        mounted() {
          axios.get(url).then(response => {
            this.items = response.data
          })
        }
      });