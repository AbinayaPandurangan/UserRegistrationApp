module.exports = {
  root: true,
  env: { browser: true, es2020: true },
  extends: [
    "eslint:recommended",
    "plugin:@typescript-eslint/recommended-type-checked",
    "plugin:react-hooks/recommended",
  ],
  ignorePatterns: ["dist", ".eslintrc.cjs"],
  transformIgnorePatterns: [`/node_modules/(?!${esModules})`],
  parser: "@typescript-eslint/parser",
  plugins: "@babel/plugin-syntax-jsx",
  rules: {
    "react-refresh/only-export-components": [
      "warn",
      { allowConstantExport: true },
    ],
    presets: [
      ["@babel/preset-env", { targets: { node: "current" } }],
      "@babel/preset-typescript",
    ],
  },
  preset: "ts-jest",
  testEnvironment: "node",
  transform: {
    "^.+\\\\\\\\.tsx?$": "ts-jest",
  },
};
