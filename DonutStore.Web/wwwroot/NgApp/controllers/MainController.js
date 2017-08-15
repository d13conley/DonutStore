class MainController {
	constructor($http) {
		this.http = $http;
		this.donuts = [];
		this.getDonuts();
		this.donut = {};
	}

	getDonuts() {
		this.http.get("api/Donuts")
			.then(res => {
				this.donuts = res.data;
			});
	}

	addDonut() {
		this.http.post("api/Donuts", this.donut)
			.then(res => {
				this.donut = {};
				this.getDonuts();
			});
	}
}