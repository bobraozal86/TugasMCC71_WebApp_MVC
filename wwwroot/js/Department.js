$(document).ready(function () {

    $('#tableDepartment').DataTable({
        ajax: {
            url: 'https://localhost:7104/api/Department',
            dataSrc: 'data',
            "headers": {
                'Content-Type': 'application/x-www-form-urlencoded'
            },
            "type": "GET",
        },
        columns: [
            {
                data: 'id',
            },
            {
                data: 'name',
            },
            {
                data: null,
                className: "d-none d-sm-table-cell",
                "render": function (data, type, row, meta) {
                    return `<button type="button">Edit</button>
                        <button type="button">Hapus</button>`
                }
            }

        ]

    });
});
//$(document).ready(function () {
//    $("#tableDepartment").DataTable({
//        $.ajax({
//            url: "https://localhost:7104/api/Department",
//            dataSrc: "data",
//            "type": "GET",
//        }, columns: [
//            {
//                data: 'Id'
//            },
//            {
//                data: 'Name'
//            },
//            {
//                data: null,
//                "render": function (data, type, row, meta) {
//                    return
//                    `<button>Edit</button> <button>Delete</button>`
//                }
//            }
//        ]);
//    });
//});

