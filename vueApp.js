const url = "/api/getdevices";

const vm = new Vue({
        el: '#app',
        data: {
          sortBy: 'status',
          sortDesc: false,
          fields: ['deviceName', 'requestedDate', 'deviceId','status','approximateAmount','actualAmount',
          { key: 'deviceName', sortable: true },
          { key: 'requestedDate', sortable: true },
          { key: 'deviceId', sortable: true },
          { key: 'status', sortable: false },
          { key: 'approximateAmount', sortable: true },
          { key: 'actualAmount', sortable: true }
        ],
          items: []
        },
        mounted() {
          axios.get(url).then(response => {
            this.items = response.data
          })
        }
      });