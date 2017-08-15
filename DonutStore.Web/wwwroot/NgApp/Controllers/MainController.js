class MainController {
    constructor($http){
        this.http = $http;
        this.donut = [];
    }
    getDonuts(){
        this.http.get("/api/donuts")
            .then(res => {
            })
            .catch(res => {
                this.donut = [];
                console.log(res);
            });
    }
}