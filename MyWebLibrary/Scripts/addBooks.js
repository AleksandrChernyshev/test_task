$(function () {
    var bookForm = '#CreateBooks';
    var $errorMesseges = $('#CreateBooks > div.text-danger.validation-summary-errors > ul > li');
    var $bookList = $('.AllBook');

    $('#SaveChangesButton').on('click', function () {

        if ($(bookForm).valid()) {
            $errorMesseges.hide();
            var id = $bookList.children().length;
            var bookName = $(bookForm + ' #BookName').val();
            var bookStyle = $(bookForm + ' #BookStyle').val();
            var bookPagesNumber = $(bookForm + ' #BookPagesNumber').val();
            
            var book = '<div class="rect">' +
                '<input name="Books[' + id + '].BookName" type="hidden" value="' + bookName + '">' +
                '<input name="Books[' + id + '].BookStyle" type="hidden" value="' + bookStyle + '">' +
                '<input name="Books[' + id + '].BookPagesNumber" type="hidden" value="' + bookPagesNumber + '">' +
                '<p>BookName: ' + bookName + '</br>' +
                'BookStyle: ' + bookStyle + '</br>' +
                'BookPagesNumber: ' + bookPagesNumber + '</br>' +
                '</p></div>';

            $bookList.append(book);

            $('#CreateBookModal').modal('hide');
        }
    });
});