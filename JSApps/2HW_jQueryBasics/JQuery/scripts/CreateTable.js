(function () {
    $(document).ready(function () {
        var students =
            [{ firstName: "Petar", lastName: "Ivanov", grade: "3" },
            { firstName: "Milena", lastName: "Grigorova", grade: "6" },
            { firstName: "Gergana", lastName: "Borisova", grade: "12" },
            { firstName: "Boyko", lastName: "Petrov", grade: "7" }];

        var tableEntries = '';
        for (var i = 0, len = students.length; i < len; i+=1) {
            tableEntries += '<tr>' +
                '<td>' + students[i].firstName + '</td>' +
                '<td>' + students[i].lastName + '</td>' +
                '<td>' + students[i].grade + '</td>' +
                '</tr>';
        }
        var table = $(
            '<table>' +
            '<tr>' +
                '<th>First Name</th>' +
                '<th>Last Name</th>' +
                '<th>Grade</th>' +
            '</tr>' +
                tableEntries +
            '</table>');

        table.css('border', '1px solid black');
        var container = $('#student-table-holder');
        container.append(table);
        
    });
}());