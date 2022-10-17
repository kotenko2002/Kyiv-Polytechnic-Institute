// Taks 1
const currentElement = document.getElementById('target-by-variant');
const nextElement = document.querySelector('#target-by-variant').nextElementSibling;

currentElement.addEventListener('click', e => changingElementClasses(e.target, 'change-color'));
nextElement.addEventListener('click', e => changingElementClasses(e.target, 'change-color'));

const changingElementClasses = (element, className) => {
  const elementClassList = element.classList;

  elementClassList.contains(className)
    ? elementClassList.remove(className)
    : elementClassList.add(className);
};

// Taks 2
const zoomScale = 1.4;

const addImage = () => {
  const sourceImageId = 'main-img';
  const addedImgClass = 'added-img';
  const imgWrapperClassName = 'deletable-img';

  const sourceImageElem = document.getElementById(sourceImageId);
  const imgElem = document.createElement('img');
  imgElem.src = sourceImageElem.src;
  imgElem.classList.add(addedImgClass);

  const containerId = 'imgs-container';
  const imgsContainer = document.getElementById(containerId);

  const wrapper = document.createElement('div');
  wrapper.classList.add(imgWrapperClassName);
  wrapper.appendChild(imgElem);
  imgsContainer.appendChild(wrapper);
};

const zoomImg = (img, zoomScale) => {
  const imgStyle = window.getComputedStyle(img);
  const transform = imgStyle.getPropertyValue('transform');
  if (!transform) {
    img.style.transform = `scale(${zoomScale})`;
    return;
  }

  if (!transform.includes('scale')) {
    img.style.transform += ` scale(${zoomScale})`;
    return;
  }

  transform.replace('scale([-]{0,1}[0-9]+[.]*[0-9]+)', `scale(${zoomScale})`);
};

const zoomLastImg = scale => {
  const imgWrapperClassName = 'deletable-img';
  const sourceImageId = 'main-img';

  const addedImgs = document.querySelectorAll(`div.${imgWrapperClassName} img `);

  if (addedImgs.length !== 0) {
    const lastImg = addedImgs[addedImgs.length - 1];
    zoomImg(lastImg, scale);
    return;
  }

  const sourceImage = document.getElementById(sourceImageId);
  zoomImg(sourceImage, scale);
};

const removeImage = () => {
    const imgWrapperClassName = 'deletable-img';
  
    const imgContainers = document.querySelectorAll(`.${imgWrapperClassName}`);
  
    if (imgContainers.length !== 0) {
      const lastImgContainer = imgContainers[imgContainers.length - 1];
      lastImgContainer.remove();
    }
};

document.querySelector('button#add').addEventListener('click', addImage);
document.querySelector('button#zoom-in').addEventListener('click', () => zoomLastImg(zoomScale));
document.querySelector('button#zoom-out').addEventListener('click', () => zoomLastImg(1 / zoomScale));
document.querySelector('button#delete').addEventListener('click', removeImage);