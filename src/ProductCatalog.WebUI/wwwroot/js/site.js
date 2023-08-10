let filterButton = document.getElementById("filterButton");

filterButton.addEventListener("click", function () {
    let filterInput = document.getElementById("filterInput");
    let filterValue = encodeURIComponent(filterInput.value);

    let pageNumber = 1;
    let url = `${indexUrl}?pageNumber=${pageNumber}&filter=${filterValue}`;

    window.location.href = url;
});

window.addEventListener('load', function () {
    let spinnerOverlay = document.getElementById('spinnerOverlay');
    spinnerOverlay.style.display = 'block';

    setTimeout(function () {
        spinnerOverlay.style.display = 'none';
    }, 500);
});

