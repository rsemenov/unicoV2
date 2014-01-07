$(function () {
    $('#brandSelect').change(function () {
        var selectedValue = $(this).val();
        $.ajax({
            url: $(this).data('url'),
            type: 'GET',
            cache: false,
            data: { value: selectedValue }
        });
    });
});