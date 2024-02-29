var dataTable;

$(document).ready(function ()
{
    loadDataTable();
});

function loadDataTable()
{
    dataTable =
        $('#tblData').DataTable({
            "ajax": { url: '/admin/product/getall' },
            "columns": [
                { data: 'brand' },
                { data: 'type' },
                { data: 'description' },
                { data: 'availableQuantity' },
                {
                    data: 'photoUrl',
                    "render": function (data)
                    {
                        return `<img src="` + data +`"
                                    width="100"
                                    height="140"
                                    class="animal-listing-img" 
                        />`
                    }
                },
                {
                    data: 'id',
                    "render": function (data)
                    {
                        return `<div class="w-75 btn-group-md" role="group">

                                    <a href="/Admin/Product/Upsert?id=${data}" class="btn btn-primary edit-btn crisp-text">
                                        <i class="bi bi-pencil-square crisp-text"></i> Edit
                                        </a>

                                    <a onClick=Delete('/Admin/Product/Delete?id=${data}') class="btn btn-danger my-1 crisp-text">
                                        <i class="bi bi-trash-fill crisp-text"></i> Delete
                                    </a>

                        </div >`
                    }
                }

            ]
        });
};


function Delete(url)
{
    Swal.fire({
        title: "Are you sure?",
        text: "You won't be able to revert this!",
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        confirmButtonText: "Yes, delete it!"
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: url,
                type: 'DELETE',
                success: function (data)
                {
                    dataTable.ajax.reload();
                    toastr.success(data.message);
                }
            })
        }
    });
}
