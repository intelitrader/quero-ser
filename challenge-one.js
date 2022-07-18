const formatNames = (...name) => {
  const fullName = name.map(name => name.trim().split(' ')).flat();
  const lastName = fullName[fullName.length - 1].toUpperCase();
  const agnome = [
    'FILHO',
    'FILHA',
    'NETO',
    'NETA',
    'SOBRINHO',
    'SOBRINHA',
    'JUNIOR'
  ];

  if (fullName.includes('')) return 'remova os espaços em branco';

  let result = '';

  if (fullName.length === 1) {
    result = `${lastName}`;
  } else if (agnome.includes(lastName) && fullName.slice(0, -1).length >= 2) {
    const nickName = fullName
      .find(name => agnome.includes(name.toUpperCase()))
      .toUpperCase();

    const middleName =
      fullName.length === 3
        ? fullName.slice(1, -1).join(' ')
        : fullName.slice(1, -2).join(' ');

    const noNickAndMiddleName = fullName
      .filter(name => name.toUpperCase() !== nickName && name !== middleName)
      .map(name => name[0].toUpperCase() + name.substring(1))
      .join(' ');

    result = `${middleName.toUpperCase()} ${nickName}, ${noNickAndMiddleName} `;
  } else {
    result = `${lastName}, ${fullName.slice(0, -1).join(' ')}`;
  }

  return result;
};
