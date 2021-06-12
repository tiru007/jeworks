const url = "/api/getdevices";

const vm = new Vue({
        el: '#app',
        data: {
          fields: ['deviceName', 'requestedDate', 'deviceId','status','approximateAmount','actualAmount'],
          items: []
        },
        mounted() {
          axios.get(url).then(response => {
            this.items = response.data
          })
        }
      });