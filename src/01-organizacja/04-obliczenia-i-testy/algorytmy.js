function poleProstokata(szerokosc, wysokosc) {
  if (!Number.isFinite(szerokosc) || !Number.isFinite(wysokosc)) {
    throw new TypeError("Boki muszą być liczbami");
  }
  if (szerokosc < 0 || wysokosc < 0) {
    throw new RangeError("Boki nie mogą być ujemne");
  }
  return szerokosc * wysokosc;
}

function srednia(values) {
  if (!Array.isArray(values) || values.length === 0) {
    throw new RangeError("Lista nie może być pusta");
  }
  if (values.some((value) => !Number.isFinite(value))) {
    throw new TypeError("Lista musi zawierać liczby");
  }
  const suma = values.reduce((result, value) => result + value, 0);
  return suma / values.length;
}

function silnia(number) {
  if (!Number.isInteger(number) || number < 0) {
    throw new RangeError("Silnia wymaga liczby całkowitej nieujemnej");
  }
  let result = 1;
  for (let current = 2; current <= number; current += 1) {
    result *= current;
  }
  return result;
}

function nwd(firstNumber, secondNumber) {
  if (!Number.isInteger(firstNumber) || !Number.isInteger(secondNumber)) {
    throw new TypeError("NWD wymaga liczb całkowitych");
  }
  let first = Math.abs(firstNumber);
  let second = Math.abs(secondNumber);
  if (first === 0 && second === 0) {
    throw new RangeError("NWD dla dwóch zer nie jest określone");
  }
  while (second !== 0) {
    const remainder = first % second;
    first = second;
    second = remainder;
  }
  return first;
}

function czyPierwsza(number) {
  if (!Number.isInteger(number) || number < 2) {
    return false;
  }
  for (let divisor = 2; divisor * divisor <= number; divisor += 1) {
    if (number % divisor === 0) {
      return false;
    }
  }
  return true;
}

module.exports = {
  poleProstokata,
  srednia,
  silnia,
  nwd,
  czyPierwsza,
};
