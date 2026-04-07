# 🐾 Huellitas - App de Adopción de Perritos

Este MVP traduce el mockup de Figma a una aplicación web inicial para validar el producto.

## 1) Idea de negocio

**Problema:** muchos refugios tienen procesos manuales y lentos para conectar perritos con familias responsables.

**Solución:** una app que centralice catálogo de perritos, formulario de solicitud y seguimiento de adopciones.

### Propuesta de valor
- Para adoptantes: búsqueda simple y proceso guiado.
- Para refugios: menor carga operativa y trazabilidad del proceso.
- Para la comunidad: más adopciones responsables y menos abandono.

### Modelo de ingresos (fases)
1. **Fase inicial (0–6 meses):** gratis para refugios para conseguir tracción.
2. **Fase de crecimiento:** plan SaaS para refugios (gestión avanzada + reportes).
3. **Fase de expansión:** alianzas con veterinarias, pet shops y seguros para mascotas.

### KPIs clave
- Tasa de solicitud → adopción efectiva.
- Tiempo promedio de cierre de adopción.
- Retención de refugios activos.
- Adopciones con seguimiento a 30/90 días.

---

## 2) Modo de gestión (operación del proyecto)

Se recomienda un enfoque **Lean + Scrum** en ciclos de 2 semanas.

### Roles mínimos
- **Product Owner:** prioriza backlog y métricas.
- **Tech Lead:** arquitectura y calidad técnica.
- **Diseño UX/UI:** consistencia con Figma.
- **Operaciones de refugio:** validación del flujo real de adopción.

### Ceremonias
- **Planning (2h):** definir sprint goal y alcance.
- **Daily (15 min):** bloqueos y progreso.
- **Review (1h):** demo a stakeholders.
- **Retro (45 min):** mejoras de proceso.

### Backlog sugerido por fases
- **MVP:** catálogo, filtros, solicitud, panel básico de revisión.
- **V1:** login de refugios, estados de solicitud, notificaciones.
- **V2:** matching inteligente, visitas programadas, firma digital.

---

## 3) Lo que ya funciona en este MVP

- Pantalla principal con propuesta de valor e indicadores.
- Catálogo de perritos con filtros por tamaño y edad.
- Formulario de solicitud con validaciones HTML5.
- Confirmación de envío en frontend.

> Nota: este MVP usa datos estáticos y no persiste información aún.

---

## 4) ¿Cómo hacerlo funcionar localmente?

Como es un sitio estático, tienes dos opciones:

### Opción A: abrir directamente
1. Abre `index.html` en tu navegador.

### Opción B: levantar servidor local (recomendado)
```bash
cd app-adopcion-perritos
python3 -m http.server 5500
```
Luego visita: `http://localhost:5500`

---

## 5) Próximos pasos técnicos

1. Agregar backend (Node.js + Express o FastAPI).
2. Base de datos (PostgreSQL) con tablas: `dogs`, `shelters`, `applications`, `users`.
3. Autenticación por roles (adoptante/refugio/admin).
4. Panel de administración para flujo de solicitudes.
5. Integración de WhatsApp/email para notificaciones automáticas.
