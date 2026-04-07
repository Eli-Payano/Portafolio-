const perros = [
  {
    nombre: 'Luna',
    edad: 'cachorro',
    tamano: 'pequeno',
    refugio: 'Hogar Canino Norte',
    descripcion: 'Juguetona, sociable y excelente con niños.',
  },
  {
    nombre: 'Max',
    edad: 'joven',
    tamano: 'mediano',
    refugio: 'Rescate Patitas Felices',
    descripcion: 'Activo, obediente y ideal para vida en apartamento.',
  },
  {
    nombre: 'Nala',
    edad: 'adulto',
    tamano: 'grande',
    refugio: 'Refugio Amigos de 4 Patas',
    descripcion: 'Tranquila, noble y perfecta para familias con patio.',
  },
  {
    nombre: 'Rocky',
    edad: 'joven',
    tamano: 'grande',
    refugio: 'Fundación Huellas de Amor',
    descripcion: 'Protector, muy leal y con entrenamiento básico.',
  },
];

const listaPerritos = document.getElementById('listaPerritos');
const filtroTamano = document.getElementById('filtroTamano');
const filtroEdad = document.getElementById('filtroEdad');
const verPerritosBtn = document.getElementById('verPerritosBtn');
const solicitudForm = document.getElementById('solicitudForm');
const mensajeExito = document.getElementById('mensajeExito');

function crearCard(perro) {
  return `
    <article class="card">
      <span class="badge">${perro.edad}</span>
      <h3>${perro.nombre}</h3>
      <p><strong>Tamaño:</strong> ${perro.tamano}</p>
      <p><strong>Refugio:</strong> ${perro.refugio}</p>
      <p>${perro.descripcion}</p>
    </article>
  `;
}

function renderPerritos() {
  const tamano = filtroTamano.value;
  const edad = filtroEdad.value;

  const resultado = perros.filter((perro) => {
    const tamanoMatch = tamano === 'todos' || perro.tamano === tamano;
    const edadMatch = edad === 'todos' || perro.edad === edad;
    return tamanoMatch && edadMatch;
  });

  listaPerritos.innerHTML = resultado
    .map(crearCard)
    .join('') || '<p>No hay resultados para este filtro.</p>';
}

filtroTamano.addEventListener('change', renderPerritos);
filtroEdad.addEventListener('change', renderPerritos);

verPerritosBtn.addEventListener('click', () => {
  document.getElementById('catalogo').scrollIntoView({ behavior: 'smooth' });
});

solicitudForm.addEventListener('submit', (event) => {
  event.preventDefault();

  const datos = new FormData(solicitudForm);
  const nombre = datos.get('nombre');

  mensajeExito.textContent = `Gracias ${nombre}, recibimos tu solicitud. Te contactaremos pronto para continuar con el proceso de adopción.`;
  solicitudForm.reset();
});

renderPerritos();
