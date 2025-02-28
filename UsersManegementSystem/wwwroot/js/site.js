// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.
const Toast = Swal.mixin({
    toast: true,
    position: "top-end",
    showConfirmButton: false,
    timer: 3000,
    timerProgressBar: true,
    didOpen: (toast) => {
        toast.onmouseenter = Swal.stopTimer;
        toast.onmouseleave = Swal.resumeTimer;
    }
});

export function toastMessage(type, message) {
    Toast.fire({
        icon: type,
        title: message
    });
}


export function addDivAlert(message) {
    let div = document.createElement("div");
    div.classList.add("has-danger", "text-danger");
    div.textContent = message;
    return div;
}

export function showAlert(target, message) {
    let div = addDivAlert(message);
    let existingAlert = target.parentNode.querySelector(".has-danger");

    if (message) {
        target.classList.add("is-invalid");
        if (!existingAlert) {
            target.parentNode.appendChild(div);

            setTimeout(() => {
                div.remove();

            }, 2000);
        }
    } else {
        target.classList.remove("is-invalid");
        target.classList.add("is-valid");
        if (existingAlert) existingAlert.remove();
    }
}

export function getCookie(name) {
    const value = `; ${document.cookie}`;
    const parts = value.split(`; ${name}=`);
    if (parts.length === 2) return parts.pop().split(';').shift();
}
export const createDatatable = (params) => {
    const newTable = new DataTable(`#${params?.id}`, {
        ajax: params?.ajaxUrl,
        destroy: true,
        lengthMenu: [
            [10, 25, 50, 100, -1],
            [10, 25, 50, 100, "Todos"],
        ],

        paging: true,
        pagingType: "simple_numbers",
        order: [],
        columnDefs: [params?.buttonsEvents ? params.buttonsEvents : ""],
        columns: params?.columns,
        buttons: params?.buttons
            ? [
                {
                    extend: "excel",
                    titleAttr: "Exportar a Excel",
                    className: "btn btn-success fw-medium text-white",
                    text: "<i class='bi bi-file-earmark-excel'></i>",
                    exportOptions: {
                        columns: params?.columnsExport,
                    },
                },
                {
                    extend: "print",
                    titleAttr: "Imprimir",
                    className: "btn btn-warning fw-medium text-white",
                    text: "<i class='bi bi-printer'></i>",
                    exportOptions: {
                        columns: params?.columnsPrint,
                    },
                },
                {
                    extend: "colvis",
                    titleAttr: "Mostrar columnas",
                    className: "btn btn-info fw-medium ",
                    text: "<i class='bi bi-layout-three-columns'></i>",
                    columns: params?.columnsSearchBuilder,
                },
            ]
            : [],
        language: {
            url: "https://cdn.datatables.net/plug-ins/2.0.2/i18n/es-ES.json",
        },
        layout: {
            top:
                params?.searchBuilder && params?.buttons
                    ? ["searchBuilder", "buttons"]
                    : null,

            bottomEnd: "paging",
        },
        searchBuilder: params?.searchBuilder
            ? {
                columns: params?.columnsSearchBuilder,
            }
            : false,
        // initComplete: function () {
        //   params?.callback();
        // },
        scrollX: true,
    });

    return newTable;
};

export async function updateDatatable(endpoint) {
    if (!$.fn.DataTable.isDataTable("#Tabla")) {
        loadUsersTable({
            id: "Tabla",
            data: newData,
            searchBuilder: true,
            buttons: true,
        });
    } else {
        const table = $("#Tabla").DataTable();
        table.ajax.reload(null, false);
        table.ajax.url(endpoint).load();
    }
};
// Write your JavaScript code.
