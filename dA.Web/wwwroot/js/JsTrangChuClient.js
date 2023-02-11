window.addEventListener("load", function () {
  const links = [...document.querySelectorAll(".header-menu-link")];
  links.forEach((item) => item.addEventListener("mouseenter", handleHoverLink));

  const line = document.createElement("div");
  line.className = "line-effect";
  document.body.appendChild(line);

  function handleHoverLink(event) {
    const offSetBottom = 5;
    const { top, left, width, height } = event.target.getBoundingClientRect();
    line.style.width = `${width}px`;
    line.style.left = `${left}px`;
    line.style.top = `${top + height + offSetBottom}px`;
  }

  const menu = document.querySelector(".header-menu");
  menu.addEventListener("mouseleave", function () {
    line.style.width = 0;
  });
});
///Js banner
//window.addEventListener("load", function () {
//  const timeSkip = 3000;
//  var arrChu = [...document.querySelectorAll(".main_banner-item")];
//  function ranDomIndex(leght) {
//    return Math.floor(Math.random() * leght);
//  }
//  setInterval(function () {
//    var index = ranDomIndex(arrChu.length);
//    var active = arrChu[index];

//    arrChu.forEach((item) => {
//      item.classList.remove("active");
//    });
//    active.classList.toggle("active");
//  }, timeSkip);
//});

/// hieu ứng silide
let swiper = new Swiper(".new-swiper", {
    spaceBetween: 24,
    loop: "true",
    slidesPerView: "auto",
    centeredSlides: true,
    pagination: {
        el: ".swiper-pagination",
        dynamicBullets: true,
    },
    breakpoints: {
        992: {
            spaceBetween: 24,
        },
    },
});
// Hieu ung
window.addEventListener("load", function () {
  const sr = ScrollReveal({
    origin: "top",
    distance: "100px",
    duration: 1500,
    reset: true,
  });

  sr.reveal(".partner__item", { interval: 200 });
  sr.reveal(".subscribe__container", { interval: 300 });
});