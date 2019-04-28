const saveCommentLikeForm = $('.SaveCommentLike');

$(document).on('submit', '.SaveCommentLike', function (e) {
    e.preventDefault();

    let self = $(this);
    let activitieCard = $(`#card-container-${e.target.name}`);
    activitieCard.loadingModal({ text: 'Cargando...', animation: 'wanderingCubes' });
    $.post(e.currentTarget.action, self.serialize(), function (res) {
        if (res) loadActividad();
    });
});

//if (res) loadActividad();