$(document).ready(() => {
    /*Procedimiento para abrir el input de tipo file al darle click al li que funciona como boton*/
    $("#boton_foto_load").on("click", () => {
        $("#foto_load").click();
    });
    /*Termina*/

   


    //Peticion ajax para subir fotos
    $('#album_form').ajaxForm(function (data) {

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
        /*$("body").loadingModal({
            text: "Cargando..."
        });*/
            $('body').loadingModal({ text: 'Cargando...', 'animation': 'wanderingCubes' });
        $("#cargar_fotos").load(`/Foto/MostrarFotos/?id=${id}`);
      
        }
    }
    /*Termina*/

    /*Ejecutamos el metodo para mostrar las fotos del usuario al cargar la pagina*/
    window.onload = galeriaFotos();
    /*Termina*/
   
   /*Este evento carga nuevamente las fotos del usuario al cerrar el modal de 'subir fotos'*/
    $("#close_uploader").on("click", () => {
        galeriaFotos();
    });
    /*Termina*/

  /*Procedimiento para borrar la foto del usuario seleccionada*/
    $(document).on("click", ".borrarFoto", (e) => {
        let id = e.target.id;
        $('body').loadingModal({ text: 'Showing loader animations...', 'animation': 'wanderingCubes' });
       
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
               
                
                let datos = {
                    fotoId: id
                }
                $.post({
                    url: "/Foto/BorrarFotoAlbum",
                    data: datos,
                    success: (data) => {
                        if (data) {
                            $('body').loadingModal('hide');
                            galeriaFotos();
                            swal("Borrada!", `La foto ha sido borrada!`, "success");
                        }
                    },
                    done: (data, err) => {
                        $('body').loadingModal('hide');
                        alert("Error al borrar la foto");
                    }
                })

                
            })
    });
    /*Termina*/

   

});
