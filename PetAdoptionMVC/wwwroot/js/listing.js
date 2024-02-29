var dataTable;

$(document).ready(function () {
    var url = window.location.href;

    if (url.includes('AnimalListings')) {
        loadAnimalListingDataTable();
    } else if (url.includes('ProductListings')) {
        loadProductListingDataTable();
    }
});

function loadAnimalListingDataTable() {
    dataTable =
        $('#tblData').DataTable({
            "ajax": { url: '/customer/listing/getallanimallistings' },
            "columns": [
                { data: 'animal.name' },
                { data: 'animal.age' },
                { data: 'animal.species' },
                { data: 'price' },
                { data: 'animal.sex' },
                {
                    data: 'animal.photoUrl',
                    "render": function (data) {
                        return `<img src="` + data + `"
                                    width="100"
                                    height="140"
                                    class="animal-listing-img" 
                        />`
                    }
                }
            ]
        });
};

function loadProductListingDataTable() {
    dataTable =
        $('#tblData').DataTable({
            "ajax": { url: '/customer/listing/getallproductlistings' },
            "columns": [
                { data: 'product.brand' },
                { data: 'product.type' },
                { data: 'product.description' },
                { data: 'price' },
                {
                    data: 'product.photoUrl',
                    "render": function (data) {
                        return `<img src="` + data + `"
                                    width="100"
                                    height="140"
                                    class="animal-listing-img" 
                        />`
                    }
                }
            ]
        });
};