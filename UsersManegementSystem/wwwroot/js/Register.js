import { toastMessage, showAlert } from "./site.js";
document.addEventListener("DOMContentLoaded", (e) => {
  let form = document.querySelector("form");
  let inputs = form.querySelectorAll("input");

  inputs.forEach((input) => {
    input.addEventListener("blur", validation);
  });
  form.addEventListener("submit", async (e) => {
    e.preventDefault();
   

    let invalidFields = form.querySelectorAll(".is-invalid");
    let emptyFields = Array.from(inputs).filter(
      (input) => input.value.trim() === ""
    );

    if (invalidFields.length > 0) {
      invalidFields[0].focus();
      return;
    }

    if (emptyFields.length > 0) {
      emptyFields[0].focus();
      emptyFields.forEach((input) => {
        input.classList.add("is-invalid");
        showAlert(input, "Este campo es obligatorio.");
      });
      return;
    }
    let inputData = {};
    inputs.forEach((input) => {
      inputData[input.id] = input.value;

    });
      console.log(inputData);

      try {
          let response = await axios.post("/Inicio/Crear", inputData, {
              headers: { "Content-Type": "application/json" },
          });
          let data = response.data;
          console.log(data)
          toastMessage(data.status, data.message);
      } catch (error) {
          console.log(error)
          toastMessage("error", error);
      }
  });
  });

function validation(e) {
  if (e.target.id == "Email") {
    emailValidation(e);
  }

  if (e.target.id == "Phone") {
    phoneValidation(e);
  }

  if (e.target.id == "Name") {
    nameValidation(e);
  }

  if (e.target.id == "Password") {
    passwordValidation(e);
  }
  if (e.target.id == "LastName") {
    nameValidation(e);
  }
}

function emailValidation(email) {
  let message = "";

  if (!/^\w+([.-_+]?\w+)*$/.test(email.target.value)) {
    message = "El nombre de usuario del correo es inválido.";
  } else if (!/@\w+([.-]?\w+)*(\.\w{2,10})+$/.test(email.target.value)) {
    message = "El dominio del correo es inválido.";
  }
  showAlert(email.target, message);
}

function phoneValidation(number) {
  let message = "";
  if (!/^[0-9\s-]+$/.test(number.target.value)) {
    message = "El teléfono solo puede contener números, espacios o guiones.";
  } else if (
    number.target.value.length < 8 ||
    number.target.value.length > 14
  ) {
    message = "El número debe tener entre 8 y 14 dígitos.";
  }
  showAlert(number.target, message);
}

function nameValidation(name) {
    let what = name.target.id == "Name" ? "nombre" : "apellido";
    let message = "";
    if (name.target.value.length < 3) {
        message = `El ${what} debe tener al menos 3 caracteres`;
    }
  else if (!/^[a-zA-Z\s]+$/.test(name.target.value)) {
    message = `El ${what} solo puede contener letras y espacios.`;
  } 
  
  showAlert(name.target, message);
}

function passwordValidation(password) {
  let message = "";

  if (password.target.value.length < 8) {
    message = "La contraseña debe tener al menos 8 caracteres.";
  } else if (!/[A-Z]/.test(password.target.value)) {
    message = "La contraseña debe tener al menos una letra mayúscula.";
  } else if (!/[!@#$%^&*.,;:]/.test(password.target.value)) {
    message = "La contraseña debe tener al menos un carácter especial.";
  }

  showAlert(password.target, message);
}
