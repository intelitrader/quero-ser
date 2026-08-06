module.exports = {
    env: {
        node: true,
    },
    extends: ['standard', 'prettier'],
    plugins: ['prettier'],
    rules: {
        semi: ['error', 'always'],
        indent: ['error', 4, { SwitchCase: 1 }],
        'comma-spacing': ['error', { before: false, after: true }],
        quotes: ['error', 'single'],
        'object-curly-spacing': [1, 'always'],
        'no-undef': 'off',
        'one-var': 'off',
        camelcase: 'off',
    },
};