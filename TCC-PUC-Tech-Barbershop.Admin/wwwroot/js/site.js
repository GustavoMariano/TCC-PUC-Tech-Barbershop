$(document).ready(function () {
    // Recupere todos os botões que abrem a modal
    const openModalButtons = document.querySelectorAll(".btn-primary");

    openModalButtons.forEach(function (openModalButton) {
        openModalButton.addEventListener("click", function () {
            const modalId = openModalButton.getAttribute("data-target");
            const modal = document.querySelector(modalId);

            // Quando o botão for clicado, mostre a modal
            modal.style.display = "block";
        });
    });

    // Quando a modal for fechada, defina o foco de volta no botão que a abriu
    $(".modal").on("hidden.bs.modal", function () {
        openModalButtons[0].focus(); // Volte o foco para o primeiro botão, mas você pode ajustar isso conforme necessário
    });
});