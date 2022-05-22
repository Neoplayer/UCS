import ValueToClass from "../components/Tester/Test/Progressbar/ValueToClass";

describe("function tests params: 90", () => {
  it("should return name of class", () => {
    expect(ValueToClass(90)).toBe("bg-red");
  });
});

describe("function tests params: 0", () => {
  it("should return name of class", () => {
    expect(ValueToClass(0)).toBe(null);
  });
});

describe("function tests params: 101", () => {
  it("should return name of class", () => {
    expect(ValueToClass(101)).toBe("bg-end");
  });
});

describe("function tests params: null", () => {
  it("should return name of class", () => {
    expect(ValueToClass(null)).toBe(null);
  });
});

