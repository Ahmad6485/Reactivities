export interface Duck{
    name: string,
    numLegs:number,
    makeSound:(sound:string)=>void
}
const duck4:Duck={
    name:'duck4',
    numLegs:2,
    makeSound:(sound:string)=>console.log(sound)
}
const duck1:Duck ={
    name: 'huey',
    numLegs:2,
    makeSound:(sound:string)=> console.log(sound)
}
const duck2:Duck={
    name:'asd',
    numLegs:2,
    makeSound: (sound:string)=> console.log(sound)
}
const duck3:Duck={
    name:'asfg',
    numLegs:4,
    makeSound:(sound : string)=> console.log(sound)
}
duck4.makeSound('asfd1')
duck4.name='afaaa';
duck1.makeSound('asdf');
duck2.makeSound('asd');
duck1.numLegs=4;
duck1.name='asf'
export const ducks=[duck1,duck2,duck3]
