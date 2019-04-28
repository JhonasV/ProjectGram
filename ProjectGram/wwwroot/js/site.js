

 /*Procedimiento para abrir el input de tipo file al darle click al li que funciona como boton*/
    $("#boton_foto_load").on("click", () => {
        $("#foto_load").click();
    });
    /*Termina*/

   


    //Peticion ajax para subir fotos
    $('#album_form').ajaxForm(function(data) {

        if (data) {
            $('body').loadingModal('hide');
            galeriaFotos();
            $("#btn_limpiar").click();
        } else {
            alert("Todos los campos son obligatorios");
            $('body').loadingModal('hide');
            $("#btn_limpiar").click();
        }
        
    });
    /*Termina*/
    $("#album_form").on('change', (e) => {
        let elemento = $("#cargar-fotos");
        let previewImg = document.createElement('img');
        let fotoUploader = $("#foto_uploader");
        if (fotoUploader) {
            let ruta = fotoUploader.attr('src');
            if (ruta) {
                previewImg.setAttribute('src', ruta);
                //previewImg.setAttribute('heigh', ruta);
                //$(previewImg).attr('src', ruta);
                elemento.append(previewImg);
            }
        }
    })

    $("#foto_uploader").on("change", (event) => {
        previewImg(event);
    })

    const previewImg = (input) => {
        let uploadTarget = $("#cargar-fotos");
        uploadTarget.html("");
        if (input.target.files[0]) {
            let reader = new FileReader();

            reader.onload = (e) => {
                let imgPath = e.target.result;
                let imgElement = `<img src="${imgPath}" style="height:100%; width:100%;" alt="Preview" />`
                uploadTarget.append(imgElement);
            }
            reader.readAsDataURL(input.target.files[0]);
        }

    }
    /*
    $(".seguir").on("click", () => {
        $(".seguir").removeClass("btn-primary");
        $(".seguir").addClass("btn-danger dejar-seguir");
       
        $(".seguir").html(`<i class="glyphicon glyphicon-check"></i> Dejar de Seguir`);
        $(".seguir").removeClass("seguir");
       
    })

    $(".dejar-seguir").on("click", () => {

        $(".dejar-seguir").removeClass("btn-danger");
        $(".dejar-seguir").addClass("btn-primary seguir");
      
        $(".dejar-seguir").html(`<i class="glyphicon glyphicon-plus-sign"></i> Seguir`);
        $(".dejar-seguir").removeClass("dejar-seguir");
        
      
    })
    */
    $('#Follow-form').ajaxForm((data) => {

        followDrawer(data);

        console.log(data);

    });

    //Funcion que dibuja el boton de seguimiento de usuarios al darle click
    const followDrawer = (state) => {
        let btn_follow = $('#btn-follow');
        let btn_follow_icon = $('#btn-follow-icon');
        let followedCounter = $('#followedCount');
        let currentCount = followedCounter.text();
        console.log(currentCount);
        btn_follow.empty();
        followedCounter.empty();
        //btn_follow.children.r
        if (state === 0) {
            //No lo sigues

            followedCounter.html(Number(currentCount) - 1);
            btn_follow.removeClass('btn-danger').addClass('btn-primary');

            btn_follow.append('<i id="btn-follow-icon" class="glyphicon glyphicon-plus-sign"></i> Seguir');
            //btn_follow_icon.removeClass('glyphicon-check').addClass('glyphicon-plus-sign');
        } else if (state === 2) {
            followedCounter.html(Number(currentCount) + 1);
            btn_follow.removeClass('btn-primary').addClass('btn-danger');
            btn_follow.append('<i id="btn-follow-icon" class="glyphicon glyphicon-check"></i> Dejar de Seguir');
            //btn_follow_icon.removeClass('glyphicon-plus-sign').addClass('glyphicon-check');

        }

    };

    /*Funcion para actualizar la foto de perfil*/
    const actualizarFotoPerfil = (ruta) => {
        
        $("#foto_perfil_actualizador").attr("src", ruta);
        $("#cerrar_modal_perfil").click();
        //$('body').loadingModal('hide');
        swal("Good job!", "La foto de perfil fue cambiada exitosamente!", "success")
    }
    /*Termina*/

    /*Peticion ajax para subir la foto de perfil*/
    $('#foto_perfil').ajaxForm(function (data) {
       
        if (data === false) {
            //alert("Debe de agregar una foto");
            sweetAlert("El archivo no debe de estar vacio!", "Porfavor seleccione una foto", "error");  
          
        } else {
        
            actualizarFotoPerfil(data);
           
        }
    });
    /*Termina*/

    /*Procedimiento para borrar la foto de perfil*/
    $(document).on("click", ".eliminarFotoPerfil", (e) => {
        
        swal({
            title: "¿Estas seguro?",
            text: "¡Esta acción no puede ser cambiada!",
            type: "warning",
            showCancelButton: true,
            confirmButtonClass: "btn-danger",
            confirmButtonText: "Si, borrala!",
            closeOnConfirm: false
        },
         () => {
                let userId = e.target.id;

                let datos = {
                    userId: userId
                }
                $.ajax({
                    method: "post",
                    url: "/Foto/EliminarFotoPerfil",
                    data: datos,
                    success: (response) => {
                        //alert(response);
                        let fotoDefault = "/images/avatar.jpeg";
                        $("#foto_perfil_actualizador").attr("src", fotoDefault);
                        $("#cerrar_modal_perfil").click();
                       
                        swal("Borrada!", "Tu foto de perfil ha sido borrada.", "success");
                    },
                    error: (err) => {
                        alert(err);
                    },
                    complete: (response, err) => {
                        console.log(response, err);
                    }
                });
              

            });
    
       
    
    });
    /*Termina*/


    /*Funcion para cargar las fotos del usuario*/
    const galeriaFotos = () =>{

        let id = $("#userId").val();
        if (id) {
      
            $('body').loadingModal({ text: 'Cargando...', 'animation': 'wanderingCubes' });
            $("#cargar_fotos").load(`/Foto/MostrarFotos/?id=${id}`);
      
        }
    }
    /*Termina*/

    /*Ejecutamos el metodo para mostrar las fotos del usuario al cargar la pagina*/
window.onload = () => {
    galeriaFotos();
    getNotifications();
};
    /*Termina*/
   
   /*Este evento carga nuevamente las fotos del usuario al cerrar el modal de 'subir fotos'*/
    $("#close_uploader").on("click", () => {
        galeriaFotos();
    });
    /*Termina*/

  /*Procedimiento para borrar la foto del usuario seleccionada*/
    $(document).on("click", ".borrarFoto", (e) => {
        let id = e.target.id;
        let body = $('body');
       
        swal({
            title: "¿Estas seguro?",
            text: "¡Esta acción no puede ser cambiada!",
            type: "warning",
            showCancelButton: true,
            confirmButtonClass: "btn-danger",
            confirmButtonText: "Si, borrala!",
            closeOnConfirm: false
        },
            () => {
                body.loadingModal({ text: 'Cargando...', 'animation': 'wanderingCubes' })

                let datos = {
                    fotoId: id
                }
                $.post({
                    url: "/Foto/BorrarFotoAlbum",
                    data: datos,
                    success: (data) => {
                        if (data) {

                            galeriaFotos();
                            swal("Borrada!", `La foto ha sido borrada!`, "success");
                        }
                    },
                    error: (res) =>{
                        swal("Error al borrar la foto!", `Error al intentar borrar la foto, intente de nuevo más tarde.`, "warning");
                    },  
                    done: (data, err) => {
                        alert("Error al borrar la foto");
                    },
                    complete: () => {
                        body.loadingModal('hide');
                    }
                });


            });
    });
    /*Termina*/


    $(document).on('submit', '.Add-Comment', function (e) {
        e.preventDefault();

        let form_submitted = $(`#${e.target.id}`);
        $(`.card-container-${e.target.name}`).loadingModal({ text: 'Publicando comentario...', 'animation': 'wanderingCubes' });
        $.post(e.target.action, form_submitted.serialize(), function (res) {
            console.log(res);
            loadActividad();
        });
    });

    $(document).on('submit', '.SaveLike', function (e) {
        e.preventDefault();
        let likeForm = $(this);
        let likeCounter = $(`.like-counter-${e.target.name}`);
        let cardContainer = $(`.card-container-${e.target.name}`);
        cardContainer.loadingModal({ text: 'Cargando...', 'animation': 'wanderingCubes' });
        $.post(e.currentTarget.action, likeForm.serialize(), function (res) {
            console.log(res);
            if (res.isLikeAdded) {
                //loadActividad();
                likeCounter.text(res.likeCount);
                drawLikeHeartIcon(e.target.name);
                let currentUserId = activitieUserInput.val();
                connection.invoke("SendNotifications", e.target.name, 1, currentUserId)
                    .catch(err => console.log(err.toString()));
            }
            cardContainer.loadingModal('hide');
            //$(`.card-container-${e.target.name}`).loadingModal('hide');
        });
    });

const drawLikeHeartIcon = (likeIconId) => {
    const likeIconSpan = $(`#${likeIconId}`);
    let likedIcon = 'glyphicon-heart';
    let likeIconEmpty = 'glyphicon-heart-empty';

    if (likeIconSpan.hasClass(likedIcon)) {

        likeIconSpan.removeClass(likedIcon);
        likeIconSpan.addClass(likeIconEmpty);
        return;
    }

    likeIconSpan.removeClass(likeIconEmpty);
    likeIconSpan.addClass(likedIcon);

};

const notificationsType = {
    LIKE: 1,
    COMMENT: 2
};

connection.on("Notifications", (notificationData) => {


    if (notificationData.notificationType === 1) {
        //drawLikeHeartIcon(notificationData.FotoId);
        getNotifications();
        drawLikeCounter(notificationData.fotoId, notificationData.count);
    }

});

const getNotifications = () => {

    $.post('/Notification/GetNotifications', (notifications) => {
        console.log(notifications);
        drawNotification(notifications);
    });
};


const drawNotification = (notifications) => {
    const notificationCounter = $('.notification-flag');
    if (notifications.length > 0) {
        notificationCounter.text(notifications.length);
        return;
    }
    notificationCounter.text(0);
};

const drawLikeCounter = (fotoId, count) => {
    let likeCounter = $(`.like-counter-${fotoId}`);
    likeCounter.text(count);
};


    $(document).on('click', '.like-btn', (e) => {
        let id = e.target.id;
        let likeForm = $(`#SaveLike-${id}`);
        likeForm.submit();
    });

    $(document).on('click', '.archive', (e) => {
        let id = $(e.target).data('id');
        let archiveForm = $(`#ArchiveButtom-${id}`);
        archiveForm.submit();
    });

    $(document).on('submit', '.SaveArchive', function (e) {
        e.preventDefault();
        let archiveForm = $(this);
        $(`.card-container-${e.currentTarget.name}`).loadingModal({ text: 'Cargando...', 'animation': 'wanderingCubes' });
        $.post(e.currentTarget.action, archiveForm.serialize(), function (res) {
            console.log(res);
            loadActividad();
        });
    });

    $(document).on('click', '.foto-detail-viewer', (e) => {
        let fotoModal = $('#fotoViewerDetails');
        let fotoId = e.target.name;

        let pictureModalImg = $('#picture-modal');
        //let modalTitleP = $('#modal-title');
        let modalContentDiv = $('.modal-content');
        let userImage = $('#user-img');
        let nickNameA = $('#nickname-foto');
        

        pictureModalImg.removeAttr('src');
        userImage.removeAttr('src');
        nickNameA.removeAttr('href');

        //modalTitleP.empty();

        modalContentDiv.loadingModal({ text: 'Cargando...', 'animation': 'wanderingCubes' });
        fotoModal.modal('show');

        $.post('/Foto/GetFoto', { id: fotoId }, function (res) {
            pictureModalImg.attr('src', res.ruta);
            userImage.attr('src', res.applicationUser.avatar);
            nickNameA.attr('href', `/Home/Account?UserName=${res.applicationUser.userName}`);
            nickNameA.html(res.applicationUser.userName);
            //modalTitleP.html(res.descripcion);
            drawComments(res.comments);
            modalContentDiv.loadingModal('hide');
        });

    });

    const drawComments = (comments) => {
        let commentItemContainer = $('#comment-item-container');
        let content = '';
        comments.forEach((comment) => {
            console.log(comment);
            let avatar = comment.applicationUser ? comment.applicationUser.avatar : '/images/avatar.jpeg';
            content = content +
                    `<li>
                        <div class='header'>
                            <img class="user-img" style='margin-right:5px;' src="${avatar}" />
                            <p class="comment-item">
                                <a class="username" style='margin-right:5px;' href="/Home/Account/?UserName=${comment.applicationUser.userName}">
                                ${comment.applicationUser.userName}
                                </a>${comment.text}
                            </p>
                        </div>
                    </li>`;
        });
        commentItemContainer.html(content);
    };



