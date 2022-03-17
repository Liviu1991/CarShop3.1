var dataTable;

$(document).ready(function () {
    loadDataTable();
});


function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "/Admin/Product/GetAll"
        },
        "columns": [
            { "data": "make", "width": "5%" },
            { "data": "model", "width": "5%" },
            { "data": "description", "width": "10%" },
            { "data": "bodyType", "width": "5%" },
            { "data": "firstRegistration", "width": "3%" },
            { "data": "gear", "width": "5%" },
            { "data": "listPrice", "width": "5%" },
            { "data": "price", "width": "5%" },
            { "data": "vehicleType.name", "width": "5%" },
            { "data": "fuelType.name", "width": "5%" },
            {
                "data": "id",
                "render": function (data) {
                    return `
                            <div class="text-center">
                                <a href="/Admin/Product/Upsert/${data}" class="btn btn-success text-white" style="cursor:pointer">
                                    <i class="fas fa-edit"></i> 
                                </a>
                                <a onclick=Delete("/Admin/Product/Delete/${data}") class="btn btn-danger text-white" style="cursor:pointer">
                                    <i class="fas fa-trash-alt"></i> 
                                </a>
                            </div>
                           `;
                }, "width": "40%"
            }
        ]
    });
}

function Delete(url) {
    swal({
        title: "Are you sure you want to Delete?",
        text: "You will not be able to restore the data!",
        icon: "warning",
        buttons: true,
        dangerMode: true
    }).then((willDelete) => {
        if (willDelete) {
            $.ajax({
                type: "DELETE",
                url: url,
                success: function (data) {
                    if (data.success) {
                        toastr.success(data.message);
                        dataTable.ajax.reload();
                    }
                    else {
                        toastr.error(data.message);
                    }
                }
            });
        }
    });
}

/*{ "data": "make", "width": "10%" },*/
           /* { "data": "model", "width": "10%" },
 { "data": "description", "width": "10%" },*/
/*   { "data": "bodyType", "width": "5%" },
   { "data": "firstRegistration", "width": "5%" },
   { "data": "listPrice", "width": "5%" },
   { "data": "gear", "width": "5%" },
   { "data": "vehicleType.name", "width": "10%" },
   { "data": "fuelType.name", "width": "5%" },*/