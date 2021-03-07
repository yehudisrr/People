$(() => {
    let count = 0;
    $("#add-row").on('click', function () {
        count++;
        $("#ppl-rows").append(
            `<table class="table">
                <tr>
                <td> 
                    <input type = "text" name = "people[${count}].FirstName" placeholder = "First Name" class= "form-control" />
                </td>
                <td>
                    <input type="text" name="people[${count}].LastName" placeholder="Last Name" class="form-control" />
                </td>
                <td>
                    <input type="text" name="people[${count}].Age" placeholder="Age" class="form-control" />
                </td>
            </tr>
</table>`);

        return false;
    });
});
