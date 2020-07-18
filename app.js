const vm = new Vue(
    {
        el: "#app",
        data: {
            teste: 'mensagem de teste',
            paginas: [],
            pagina: false
        },
        methods: {
            fetchMenu() {
                fetch("./api/paginas.json")
                    .then(r => r.json())
                    .then(r => {
                        this.paginas = r;
                    });
            },
            fetchPagina(nome) {
                const nomeLimpo = nome.replace(".pg", "");
                console.log(nomeLimpo);
                fetch(`./api/paginas/${nomeLimpo}/pagina.json`)
                    .then(r => r.json())
                    .then(r => {
                        this.pagina = r;
                    });
            }
        },
        created() {
            this.fetchMenu();
        }
    }
)