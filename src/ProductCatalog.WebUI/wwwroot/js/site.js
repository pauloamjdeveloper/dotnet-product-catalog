function showSpinner() {
    let spinnerOverlay = document.getElementById('spinnerOverlay');

    if (spinnerOverlay) {
        spinnerOverlay.style.display = 'flex';
    }
}

function hideSpinner() {
    let spinnerOverlay = document.getElementById('spinnerOverlay');

    if (spinnerOverlay) {
        spinnerOverlay.style.display = 'none';
    }
}

window.addEventListener('load', function () {
    showSpinner();
    setTimeout(function () {
        hideSpinner();
    }, 1000);
});

let filterButton = document.getElementById("filterButton");

filterButton.addEventListener("click", function () {
    showSpinner();

    let filterInput = document.getElementById("filterInput");
    let filterValue = encodeURIComponent(filterInput.value);

    let pageNumber = 1;
    let url = `${indexUrl}?pageNumber=${pageNumber}&filter=${filterValue}`;

    window.location.href = url;

    setTimeout(function () {
        hideSpinner();
    }, 1000);
});
