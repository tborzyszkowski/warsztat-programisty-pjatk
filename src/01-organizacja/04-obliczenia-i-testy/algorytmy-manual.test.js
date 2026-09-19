const assert = require("node:assert/strict");
const {
  poleProstokata,
  srednia,
  silnia,
  nwd,
  czyPierwsza,
} = require("./algorytmy");

assert.equal(poleProstokata(4, 3), 12);
assert.equal(poleProstokata(0, 4), 0);
assert.throws(() => poleProstokata(-1, 4), RangeError);

assert.equal(srednia([2, 4, 6]), 4);
assert.equal(srednia([8]), 8);
assert.throws(() => srednia([]), RangeError);

assert.equal(silnia(5), 120);
assert.equal(silnia(0), 1);
assert.throws(() => silnia(-1), RangeError);

assert.equal(nwd(18, 24), 6);
assert.equal(nwd(0, 9), 9);
assert.throws(() => nwd(0, 0), RangeError);

assert.equal(czyPierwsza(17), true);
assert.equal(czyPierwsza(2), true);
assert.equal(czyPierwsza(1), false);
assert.equal(czyPierwsza(21), false);

console.log("Wszystkie przykładowe testy zakończyły się powodzeniem.");
