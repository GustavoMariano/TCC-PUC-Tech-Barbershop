$(document).ready(function () {
    const openModalButtons = document.querySelectorAll(".btn-primary");

    openModalButtons.forEach(function (openModalButton) {
        openModalButton.addEventListener("click", function () {
            const modalId = openModalButton.getAttribute("data-target");
            const modal = document.querySelector(modalId);

            modal.style.display = "block";
        });
    });

    $(".modal").on("hidden.bs.modal", function () {
        openModalButtons[0].focus();
    });
});